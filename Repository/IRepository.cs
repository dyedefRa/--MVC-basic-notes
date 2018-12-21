 public  interface IRepository<T> where T:class
    {
       
        IEnumerable<T> GetAll();
        T GetByID(int id);

        T Get(Expression<Func<T, bool>> kosul);
        IQueryable<T> GetMany(Expression<Func<T, bool>> kosul);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        int Count();
        void Save();


    }