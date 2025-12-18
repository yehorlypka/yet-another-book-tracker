namespace YABT.Services;

public class ToastService
{
    public event Action<string>? OnShow;
    public event Action? OnHide;

    public void ShowToast(string message) => OnShow?.Invoke(message);
    public void HideToast() => OnHide?.Invoke();
}