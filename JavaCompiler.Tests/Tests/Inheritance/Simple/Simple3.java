public class Simple1 {
	public static void main(String[] args) {
		Lamp l = new AdjustableLamp(true);
		System.out.println(l);

		l.pressSwitch();
		System.out.println(l);

		AdjustableLamp adjL = (AdjustableLamp) l;
		System.out.println(adjL);

		adjL.pressSwitch();
		adjL.dim();
		System.out.println(adjL);

		l = new Lamp(false);
		((AdjustableLamp) l).dim();
		System.out.println(l);
	}
}