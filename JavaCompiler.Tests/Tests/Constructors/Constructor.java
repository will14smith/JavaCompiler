class Constructor {
  public int f;

  public Constructor() {
    this.f = 10;
  }

  public static void main(String[] args) {
	Constructor c = new Constructor();

	System.out.print(c.f);
  }
}