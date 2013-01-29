public class Exercise1 {
  public static void main(String[] args){
    int n = Integer.parseInt(args[0]);
    
    while(n != 1){
      System.out.print(n + " ");
      
      n = next(n);
    }
    
    System.out.println(n);
  }
  
  public static int next(int x){
    if(x % 2 == 0){
      return x / 2;
    }else{
      return 3*x + 1;
    }
  }
}
