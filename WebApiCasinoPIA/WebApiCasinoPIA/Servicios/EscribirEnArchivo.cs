namespace WebApiCasinoPIA.Servicios
{
    public class EscribirEnArchivo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string fileName = "Archivo 1.txt";
        private Timer timer;

        public EscribirEnArchivo(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            Escribir("Proceso iniciado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Proceso finalizado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            return Task.CompletedTask;
        }

        public void DoWork(object state)
        {
            Escribir("Estado de las rifas: correcto");
        }

        private void Escribir(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{fileName}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(msg); }
        }
    }
}