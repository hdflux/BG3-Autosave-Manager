class TimerPlus : System.Windows.Forms.Timer
{
    public int Duration;
    public int RemainingTime;
    public Boolean IsRunning = false;
    public Boolean ResumePlaying = false;
    public event EventHandler? TimerStarted;
    public event EventHandler? TimerStopped;
    public TimerPlus(int interval, int duration)
    {
        Interval = interval;
        Duration = duration;
        RemainingTime = duration;

        this.Tick += OnTick;
    }
    private void OnTick(object? sender, EventArgs e)
    {
        RemainingTime -= Interval / 1000; // Update remaining time
    }
    public new void Start()
    {
        base.Start();
        OnTimerStarted(EventArgs.Empty); // Trigger the event
        IsRunning = true;
    }
    public new void Stop()
    {
        base.Stop();
        OnTimerStopped(EventArgs.Empty); // Trigger the event
        IsRunning = false;
    }
    protected virtual void OnTimerStarted(EventArgs e)
    {
        TimerStarted?.Invoke(this, e);
    }
    protected virtual void OnTimerStopped(EventArgs e)
    {
        TimerStopped?.Invoke(this, e);
    }
}
static class Prompt
{
    public static string ShowDialog(string title, string labelText, string defaultValue = "")
    {
        Form prompt = new()
        {
            Width = 400,
            Height = 200,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = title,
            StartPosition = FormStartPosition.CenterScreen
        };

        Label label = new() { Left = 20, Top = 20, Text = labelText, AutoSize = true };
        TextBox textBox = new() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
        Button confirmation = new() { Text = "OK", Left = 270, Width = 90, Top = 100, DialogResult = DialogResult.OK };

        prompt.Controls.Add(label);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : defaultValue;
    }
}
