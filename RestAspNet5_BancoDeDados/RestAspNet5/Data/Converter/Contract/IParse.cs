using System.Collections.Generic;

namespace RestAspNet5.Data.Converter.Contract
{
    public interface IParse<O, D>
    {
        D Parse(O origem);
        List<D> Parse(List<O> origem);
    }
}
