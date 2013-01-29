class SuperConstructor extends Constructor {
  public SuperConstructor() {
    f = 5;
  }
  
  public static void main(String[] args) {
    SuperConstructor c = new SuperConstructor();

    System.out.print(c.f);
  }
}