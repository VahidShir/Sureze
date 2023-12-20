using Sureze.Samples;
using Xunit;

namespace Sureze.EntityFrameworkCore.Applications;

[Collection(SurezeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SurezeEntityFrameworkCoreTestModule>
{

}
