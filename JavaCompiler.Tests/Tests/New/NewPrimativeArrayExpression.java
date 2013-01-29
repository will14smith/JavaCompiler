import java.util.Arrays;

public class NewPrimativeArrayExpression {
  public static void main(String[] args){
    int count = 10;
  
    int[] is = new int[count + 1];
    
    is[0] = 10;
    
    System.out.println(Arrays.toString(is));
  }
}