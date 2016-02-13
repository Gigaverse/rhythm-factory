import ddf.minim.*;
import ddf.minim.analysis.*;
import ddf.minim.effects.*;
import ddf.minim.signals.*;
import ddf.minim.spi.*;
import ddf.minim.ugens.*;

PFont label;

void setup()
{
  size(1280,720);
  noStroke();
  background(0);
  label = createFont("Dialog.bold-48.ttf",32);
  text("word", 12, 60);
}

void draw()
{
  fill(#374A67);
  rect(0, 0, width/4, height);
}