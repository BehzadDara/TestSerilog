using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("../../../log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(evt => evt.Level >= LogEventLevel.Error)
        .WriteTo.File("../../../logError.txt", rollingInterval: RollingInterval.Day)
        )
    .CreateLogger();

Log.Debug("This is a debug message");
Log.Information("This is an information message");
Log.Warning("This is a warning message");
Log.Error("This is an error message");
Log.Fatal("This is a fatal message");

Log.CloseAndFlush();