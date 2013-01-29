import java.util.Arrays;
import java.util.Random;

public class Exercise3 {
  public static void main(String[] args){
    Random generator = new Random();
    int[] numbers = new int[6];
  
    for(int i = 0; i < numbers.length; i++){
      numbers[i] = getUniqueRandom(generator, numbers);
      
      System.out.println("Number " + (i + 1) + ": " + numbers[i]);
    }
    
    int bonus = getUniqueRandom(generator, numbers);
    
    System.out.println("Bonus Number: " + bonus);
    
  }

  public static int getUniqueRandom(Random generator, int[] numbers) {
    int n = generator.nextInt(48) + 1;
    
    while(Arrays.asList(numbers).contains(n)){
      n = generator.nextInt(48) + 1;
    }
    
    return n;
  }
}
