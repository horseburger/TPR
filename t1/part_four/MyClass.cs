using System;
using part_one;
using part_two;

namespace part_four
{
    class DataService
    {
        private DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }
    }
}

