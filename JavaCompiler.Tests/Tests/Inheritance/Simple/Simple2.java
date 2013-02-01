public class Simple2 {
	public static void main(String[] args) {
		Lamp l = new Lamp(true);
		System.out.println(l);

		l.pressSwitch();
		System.out.println(l);

		AdjustableLamp adjL = new AdjustableLamp(false);
		System.out.println(adjL);

		adjL.pressSwitch();
		adjL.dim();
		System.out.println(adjL);

		l = new AdjustableLamp(false);
		System.out.println(l);

		l.pressSwitch();
		System.out.println(l);
	}
}