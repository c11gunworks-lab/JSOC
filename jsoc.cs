using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;


namespace JSOC;

[Injectable(TypePriority = OnLoadOrder.Preload + 2), UsedImplicitly]

public class Jsoc(
    
    WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib,
    ILogger<Jsoc> log
    ) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
       var assembly = Assembly.GetExecutingAssembly();
       await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
       foreach (var name in assembly.GetManifestResourceNames())
       {
           log.LogDebug("[JSOC] Embedded resource: {Res}", name);
       }
       await wttServerCommonLib.CustomLocaleService.CreateCustomLocales(assembly);
       await wttServerCommonLib.CustomAssortSchemeService.CreateCustomAssortSchemes(assembly);
       log.LogInformation("The JSOC Service Weapon Replacement Program has now begun");

    }
    
   
}
