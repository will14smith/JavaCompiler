public class Simple1 {
	public static void main(String[] args) {
		AdjustableLamp lamp = new AdjustableLamp(true);
		System.out.println(lamp);

		lamp.pressSwitch();
		lamp.dim();

		System.out.println(lamp);
	}
}