class SuperParamConstructor extends ParamConstructor {
  public SuperParamConstructor(int f) {
    super(f);
  }
  
  public static void main(String[] args) {
    SuperParamConstructor c = new SuperParamConstructor(20);

    System.out.print(c.f);
  }
}