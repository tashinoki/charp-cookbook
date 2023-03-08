namespace charp_cookbook.Application;

// サードパーティライブラリで提供されている Service class
// interface を実装しておらず、もし生成方法が複雑だとアプリケーションコードがひどい事になる
public class ThirdPartyService
{
    public void Validate()
    {
        Console.WriteLine("validate");
    }
}
