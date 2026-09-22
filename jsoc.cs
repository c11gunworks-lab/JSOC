using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;


namespace JSOC;

[Injectable(TypePriority = OnLoadOrder.Preload + 2), UsedImplicitly]

public class JSOC(
    
    WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib,
    ILogger<JSOC> log
    ) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
       var assembly = Assembly.GetExecutingAssembly();
       await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
       foreach (var name in assembly.GetManifestResourceNames())
       {
           log.LogDebug("[JSOC-SWR] Embedded resource: {Res}", name);
       }
       await wttServerCommonLib.CustomQuestService.CreateCustomQuests(assembly);
       await wttServerCommonLib.CustomQuestZoneService.CreateCustomQuestZones(assembly);
       await wttServerCommonLib.CustomLocaleService.CreateCustomLocales(assembly);
       await wttServerCommonLib.CustomAssortSchemeService.CreateCustomAssortSchemes(assembly);
       log.LogInformation("Loaded Spy's JSOC-SWR-FDK. Pretty CAG eh?");

    }
    
   
}
