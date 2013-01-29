class ParamConstructor {
  public int f;

  public ParamConstructor(int f) {
    this.f = f;
  }
  
  public static void main(String[] args) {
    ParamConstructor c = new ParamConstructor(15);

    System.out.print(c.f);
  }
}