class ParamConstructor2 {
  public int f;

  public ParamConstructor2() {
    this(11);
  }
  public ParamConstructor2(int f) {
    this.f = f;
  }
  
  public static void main(String[] args) {
    ParamConstructor2 c = new ParamConstructor2();

    System.out.print(c.f);
  }
}