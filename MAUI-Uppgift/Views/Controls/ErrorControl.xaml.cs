namespace MAUI_Uppgift.Views.Controls;

public partial class ErrorControl : ContentView
{
	public ErrorControl()
	{
		InitializeComponent();
	}
	public static readonly BindableProperty HasErrorProperty =
		BindableProperty.Create(nameof(HasError), typeof(bool), typeof(ErrorControl), false );
    public bool HasError
	{
		get => (bool)GetValue(HasErrorProperty);
		set => SetValue(HasErrorProperty, value);
    }

	public static readonly BindableProperty ErrorMessageProperty = 
		BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ErrorControl), string.Empty);
	public string ErrorMessage
	{
		get => (string)GetValue(ErrorMessageProperty);
		set => SetValue(ErrorMessageProperty, value);
    }
}