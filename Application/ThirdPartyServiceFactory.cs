namespace charp_cookbook.Application;

internal interface IThirdPartyServiceFactory
{
    ThirdPartyService Create();
}

// サードパーティ Service を生成するための Factory
// ここに生成ロジックを凝縮させて、IoC で Factory を使いまわす
internal class ThirdPartyServiceFactory: IThirdPartyServiceFactory
{
    public ThirdPartyService Create()
    {
        return new ThirdPartyService();
    }
}

