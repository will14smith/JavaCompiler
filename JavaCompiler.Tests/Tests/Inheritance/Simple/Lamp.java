public class Lamp {
	protected boolean isOn;

	public Lamp(boolean isOn) {
		this.isOn = isOn;
	}

	public void pressSwitch() {
		isOn = ! isOn;
	}

	public String toString() {
		return "Lamp("
			+ (isOn ? "on" : "off")
			+ ")";
	}
}