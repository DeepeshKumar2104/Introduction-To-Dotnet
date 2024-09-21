namespace CodefirstApproach.Reposit
{
    public interface IProduct
    {
        List<Product> GetAllProduct();
        Product GetAllProductbyId(int id);
    }
}
