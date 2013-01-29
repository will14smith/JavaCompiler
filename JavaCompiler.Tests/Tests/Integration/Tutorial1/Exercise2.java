public class Exercise2 {
  public static void main(String[] args){
    for(int n = 0; n < 2000; n++){
      int ncubed = (int) Math.pow(n, 3);
      
      if(isPalindrome(String.valueOf(ncubed))){
        System.out.println(n + " cubed is " + ncubed);
      }
    }
  }
  
  public static Boolean isPalindrome(String s){
    int length = s.length();
    int loops = (int) Math.ceil(length / 2);
    
    for(int i = 0; i < loops; i++){
      if(s.charAt(i) != s.charAt(length - i - 1)){
        return false;
      }
    }
    
    return true;
  }
}
