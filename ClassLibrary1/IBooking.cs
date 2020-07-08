using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public interface IBooking {
        void Create();
        void Read();
        void Edit();
        void Delete();
    }
}