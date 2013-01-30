public class Simple1 {
	public static void main(String[] args) {
		AdjustableLamp lamp = new AdjustableLamp(true);
		System.out.println(lamp);

		lamp.dim();
		lamp.pressSwitch();

		System.out.println(lamp);
	}
}