namespace VideoCutterApp;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
#endif

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        // Modificar propriedades da janela via Handler Mapper
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate(); // Necessário para obter o handle

            IntPtr windowHandle = WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            // Definir tamanho via AppWindow (alternativa a CreateWindow)
            const int fixedWidth = 650;
            const int fixedHeight = 800;
            appWindow.Resize(new SizeInt32(fixedWidth, fixedHeight));

            // Impedir redimensionamento
            if (appWindow.Presenter is OverlappedPresenter overlappedPresenter)
            {
                overlappedPresenter.IsResizable = false;
                overlappedPresenter.IsMaximizable = false;
            }
#endif
        });
	}

    // Método CreateWindow pode ser removido ou deixado vazio,
    // pois o tamanho agora é definido no Mapper.
    // Vamos remover para evitar confusão.
    /*
    protected override Window CreateWindow(IActivationState? activationState) 
    {
        var window = base.CreateWindow(activationState);

        // Tamanho agora definido no Mapper acima
        // window.Width = 650;
        // window.Height = 800;

        // Centralizar (opcional)
        window.X = -1; 
        window.Y = -1; 

        return window;
    }
    */
}
