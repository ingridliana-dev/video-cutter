namespace VideoCutterApp;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;
#endif

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		var window = base.CreateWindow(activationState);

		const int fixedWidth = 650;
		const int fixedHeight = 800; // Altura também precisa ser definida

		window.Width = fixedWidth;
		window.Height = fixedHeight;

		// Temporariamente comentado para teste
/*
#if WINDOWS
		var nativeWindowHandle = WindowNative.GetWindowHandle(window);
		var windowId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
		var appWindow = AppWindow.GetFromWindowId(windowId);

		if (appWindow.Presenter is OverlappedPresenter overlappedPresenter)
		{
			overlappedPresenter.IsResizable = false;
			// overlappedPresenter.IsMaximizable = false; 
		}
#endif
*/

		// Centralizar (opcional, mas bom para janelas fixas)
		window.X = -1; 
		window.Y = -1; 

		return window;
	}
}
