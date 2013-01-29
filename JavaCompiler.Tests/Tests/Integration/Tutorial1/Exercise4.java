import java.util.Random;

public class Exercise4 {
  public static void main(String[] args){
    int x = Integer.parseInt(args[0]);
    
    Boolean[] used = new Boolean[x];
    Random generator = new Random();
    
    System.out.println("Generating random numbers:");
    
    int n = 0;
    while(!allTrue(used)){
      int i = generator.nextInt(x);
      used[i] = true;
      
      System.out.print(i);
      
      if(!allTrue(used)){
        System.out.print(", ");
      }
      
      n++;
    }
    
    System.out.println("\nI had to generate " + n + " random numbers between 0 and " + (x - 1) + 
        " to have produced all such numbers at least once.");
  }

  private static boolean allTrue(Boolean[] used) {
    for(Boolean x : used) {
      if(x == null || x != true) {
        return false;
      }
    }
    
    return true;
  }
}
