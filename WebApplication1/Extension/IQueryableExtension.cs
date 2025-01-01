namespace WebApplication1.Extension
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Random<T>(this IQueryable<T> query,int randNum)
        {
            Random random = new Random();
            int num = random.Next(0, randNum);
            return query.Skip(num);
        }
    }
}
