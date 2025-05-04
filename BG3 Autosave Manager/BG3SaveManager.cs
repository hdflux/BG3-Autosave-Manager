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