import ddf.minim.*;
import ddf.minim.analysis.*;
import ddf.minim.effects.*;
import ddf.minim.signals.*;
import ddf.minim.spi.*;
import ddf.minim.ugens.*;

long millis;
PFont label;
PrintWriter output;
int[] subdivs = {4,8,16,32};

//line stores the current time in the song as a position
float line;

//bpm counter counts which note of 4 it's counting, timer holds milis() to find time elapsed, solver gets the final bpm
int songpos = 0, bpmtimer = 0, bpmsolver = 0, measurestop;
int sub = 0, subdiv = subdivs[sub], bpmcounter = 0;
double BPM;
ArrayList<Note> notes = new ArrayList<Note>();



boolean start, bpm;

Minim minim;
AudioPlayer player;

void setup()
{
  size(1280,720);
  background(0);
  label = createFont("Dialog.bold-48.vlw",32);
  textAlign(CENTER);
  smooth();
  output = createWriter("test.rff");
  minim = new Minim(this);
  player = minim.loadFile("rolling.mp3");
  player.play();
}

void draw()
{
  println(notes);
  subdiv = subdivs[sub];
  noStroke();
  rectMode(CORNER);
  //background
  fill(0);
  rect(0, 0, width, height);
  
  if(!start)
  {
      textSize(48);
      fill(#D8DDEF);
      text("HIT ANY BUTTON WHEN YOU WOULD\n PUT THE FIRST NOTE DOWN", (width/2), height/2);
      return;
  }
  if(!bpm)
  {
      textSize(48);
      fill(#D8DDEF);
      text("HIT ANY BUTTON 8 TIMES IN BEAT\n" + bpmcounter, (width/2), height/2);
      return;
  }
  
  /*
  *   REGION - UI
  */

  //left bar
  fill(#374A67);
  rect(0, 0, width/4, height);
  
  //sub buttons
  fill(#011627);
  rect(0, (2*height)/10, (width/8) - (width/16), (height)/10);
  rect((width/8) + (width/16), (2*height)/10, (width/8) - (width/16), (height)/10);
  
  //measure buttons
  fill(#011627);
  rect(0, (4*height)/10, (width/8) - (width/16), (height)/10);
  rect((width/8) + (width/16), (4*height)/10, (width/8) - (width/16), (height)/10);
  
  //bpm button
  rect(0, (4*height)/5, width/4, (height)/5);
  
  //logo
  fill(#721817);
  rect(0, 0, width/4, height/10);
  fill(#D8DDEF);
  rectMode(CENTER);
  textSize(42);
  text("MUSIC MAPPER", (width/8), (height*1.5)/20);
  
  //sub
  text("SUBDIVISION", (width/8), (height*3.5)/20);
  text(subdiv+"", (width/8), (height*11)/40);
  
  //measure
  textSize(32);
  text("MEASURE", (width/8), (height*9.25)/20);
  
  //note lines
  stroke(#D8DDEF);
  for(int i = 1; i <= 5; i++)
  {
    strokeWeight(2);
    line(width/4, (height*i)/6, width,(height*i)/6);
  }
  
  //subdivision lines
  for(int i = 1; i <= subdiv; i++)
  {
    strokeWeight(1);
    if(subdiv == 4)
    {
          strokeWeight(3);
    }
    if(subdiv == 8 && i%2==0)
    {
          strokeWeight(3);
    }
    if(subdiv == 16&& i%4==0)
    {
          strokeWeight(3);
    }
    if(subdiv == 32&& i%8==0)
    {
          strokeWeight(3);
    }
    line(width/4 + ((0.75*width)*i)/(subdiv), 0,width/4 + (0.75*width*i)/(subdiv),height);
  }
  
  /*
  *   END REGION - UI
  */
  for(Note n : notes)
  {
        n.render();
  }
  
  line = map(player.position(), songpos, measurestop, width/4, width);
  stroke(#721817);
  strokeWeight(3);
  line(line, 0, line, height);
}

void keyPressed()
{
    if(!start)
    {
       songpos = player.position();
       println(songpos);
       start = true;
    }
    else if(!bpm)
    {
      if(bpmcounter == 0)
      {
        bpmtimer = millis();
        bpmcounter++;
      }
      else
      {
        bpmsolver += (millis() - bpmtimer);
        bpmcounter++;
        bpmtimer = millis();
        
        if(bpmcounter == 8)
        {
          bpm = true;  
          bpmsolver /= 8;
          BPM = (60/((double)bpmsolver/1000));
          println(BPM);
          measurestop = songpos+(bpmsolver*4);
          player.setLoopPoints(songpos, measurestop);
          player.loop();
          
        }
      }
    }
}

void mouseClicked()
{
    if(start) {
       //subdiv buttons
       if(subleft())
       {
         sub = sub == 0 ? 3: sub-1;
         return;
       }
       if(subright())
       {
         sub = (sub+1)%4;
         return;
       }
       
       //measures **LOTS OF WORK INBOUND**
       if(measureleft())
       {
          return;
       }
       if(measureright())
       {
          for(Note n : notes)
          {
              output.println(n);  
          }
          output.flush();
          notes = new ArrayList<Note>();
          int p = measurestop - songpos;
          songpos = measurestop;
          measurestop += p;
          player.setLoopPoints(songpos, measurestop);
          return;
       }
       
       if(bpmbutton())
       {
           songpos = max(0, songpos - 2000);
           bpmcounter = 0;
           bpmsolver = 0;
           bpmtimer = 0;
           bpm = false;
           start = false;
           player.cue(songpos);
           player.play();
           return;
       }
       if(mouseX > width/4)
       {
         Note n = new Note((byte)(((double)mouseY/height)*6),(byte)1,(int)(songpos + (measurestop-songpos)*(int)map(mouseX, width/4, width, 0, subdiv)/subdiv));
         for(Note not : notes)
         {
           if(not.compareTo(n) == 0)
           {
               return;  
           }
         }
         int currnote = (int)map(mouseX, width/4, width, 0, subdiv);
         n.store(((int)(width/4 + currnote*(0.75*width/subdiv))),(int)((n.type)*(height/6)),(int)(width*0.75/subdiv),(height/6));
         notes.add(n);
       }
       //TODO - deal with laying notes out
    }    
}

boolean subleft()
{
  if(mouseX > 0 && mouseY > (2*height)/10 && mouseX < (width/8) - (width/16) && mouseY < (3*height)/10)
  {
    return true; 
  }
  return false;
}

boolean subright()
{
  if(mouseX > (width/8) + (width/16) && mouseY > (2*height)/10 && mouseX < (width/4) && mouseY < (3*height)/10)
  {
    return true; 
  }
  return false;
}

boolean measureleft()
{
  if(mouseX > 0 && mouseY > (4*height)/10 && mouseX < (width/8) - (width/16) && mouseY < (5*height)/10)
  {
    return true; 
  }
  return false;
}

boolean measureright()
{
  if(mouseX > (width/8) + (width/16) && mouseY > (4*height)/10 && mouseX < (width/4) && mouseY < (5*height)/10)
  {
    return true; 
  }
  return false;
}

boolean bpmbutton()
{
    if(mouseX > 0 && mouseY > (4*height)/5 && mouseX < width/4 && mouseY < height)
    {
        return true;  
    }
    return false;
}

int dt()
{
    return (int)(millis() - millis);  
}