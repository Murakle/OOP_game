using Core.Army;

namespace Core
{
    public class Range<T>
    {
        private T from;
        private T to;

        public Range(T from, T to)
        {
            this.from = from;
            this.to = to;
        }

        public virtual T From
        {
            get { return from; }
            set { this.from = value; }
        }

        public virtual T To
        {
            get { return to; }
            set { this.to = value; }
        }


        public override string ToString()
        {
            return "Range{" + from +
                   " : " + to +
                   '}';
        }
    }
}