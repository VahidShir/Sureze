using Xunit;

namespace Sureze.EntityFrameworkCore;

[CollectionDefinition(SurezeTestConsts.CollectionDefinitionName)]
public class SurezeEntityFrameworkCoreCollection : ICollectionFixture<SurezeEntityFrameworkCoreFixture>
{

}
