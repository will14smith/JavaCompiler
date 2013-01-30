public class AdjustableLamp extends Lamp {
	private double brightness;

	public AdjustableLamp(boolean isOn) {
		super(isOn);
		brightness = 1.0;
	}

	public void pressSwitch() {
		super.pressSwitch();
		brightness = 1.0;
	}

	public void dim() {
		if (brightness > 0.1) {
			brightness -= 0.1;
		}
	}

	public String toString() {
		return “AdjustableLamp("
			+ (isOn ? "on" : "off")
			+ ", " + brightness + ")";
	}
}