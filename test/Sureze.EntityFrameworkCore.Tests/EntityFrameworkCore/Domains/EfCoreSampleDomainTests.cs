using Sureze.Samples;
using Xunit;

namespace Sureze.EntityFrameworkCore.Domains;

[Collection(SurezeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SurezeEntityFrameworkCoreTestModule>
{

}
