public class Note
{
    int milis;
    public byte type, len;
    int x1, y1, x2, y2;
    
    public Note(byte type, byte len, int milis)
    {
      this.type = type;
      this.len = len;
      this.milis = milis;
    }
    
    public void store(int x1, int y1, int x2, int y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }
    
    public void render()
    {
      rectMode(CORNER);
      fill(#306B34);
      rect(x1,y1,x2,y2);
    }
    
    public int compareTo(Note n)
    {
       return(milis - n.milis == 0 ? n.type - type : milis - n.milis);  
    }
    
    public String toString()
    {
         return String.format("%d %d %d", len, type, milis);
    }
}