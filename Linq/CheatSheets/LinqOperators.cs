using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RiskAndPricingSolutions.Linq.CheatSheets
{
    [TestFixture]
    public class OperatorCheatSheet
    {
        [Test]
        public void TestLinOperatorCheatSheet()
        {
            // Where(Func<TSource,bool> predicate)
            //	Returns all elements that satisfy the predicatr
            new[] { 1, 2, 3 }.Where(x => x > 1)
                .WriteLine("new[] {1,2,3}.Where(x => x>1)");

            // Where(Func<TSource,int,bool>)
            //	Returns a new sequence contains all the elements
            // 	of the original sequence which satify the predicate. The
            //  predicate takes the element index as an argument
            new[] { 1, 2, 3 }.Where((x, i) => i % 2 == 0)
                .WriteLine("new[] { 1, 2, 3 }.Where((x,i) => i %2 ==0)");

            // Take<int> 
            //	Returns a new sequence consistening of the first n 
            //	elements of the source sequence. If n is more than the
            // 	length of the input sequence returns whole sequence
            new[] { 1, 2, 3 }.Take(2)
                .WriteLine("new[] { 1, 2, 3 }.Take(2)");

            // Skip<int> 
            //	Returns a new sequence consistening input sequence  
            //	less the first n elements. If n is greater than the 
            //	length of the sequence returns the empty sequence
            new[] { 1, 2, 3 }.Skip(2)
                .WriteLine("new[] { 1, 2, 3 }.Skip(2)");

            // TakeWhile(Func<TSource,bool>) 
            //	Returns elements until the first element 
            // 	that fails the predicate
            new[] { 1, 2, 3 }.TakeWhile(x => x < 3)
                .WriteLine("new[] { 1, 2, 3 }.TakeWhile(x=>x<3)");

            // SkipWhile(Func<TSource,bool>) 
            //	Skips elements until the predicate fails
            new[] { 1, 2, 3 }.SkipWhile(x => x < 3)
                .WriteLine("new[] { 1, 2, 3 }.SkipWhile(x => x < 3)");

            // Distrinct
            //	Elements duplicates
            new[] { 1, 2, 1, 2, 3 }.Distinct()
                .WriteLine("new[] { 1, 2, 1, 2, 3 }.Distinct()");

            // Contains(TSource)
            // Returns true if the sequence contains the specified elemtm
            new[] { 1, 2 }.Contains(3)
                .WriteLine("new[] { 1, 2}.Contains(3)");

            // Any(Func<TSource,bool>)
            // Returns true if any element satisfies the predicate
            new[] { 1, 2 }.Any(x => x % 4 == 0)
                .WriteLine("new[] { 1, 2 }.Any(x=>x%4==0)");

            // All(Func<TSource,bool>)
            // Returns true if all element satisfies the predicate
            new[] { 1, 2 }.All(x => x < 3)
                .WriteLine("new[] { 1, 2 }.All(x => x <3)");

            // SequenceEqual
            // Returns true if two sequences are equal
            new[] { 1, 2 }.SequenceEqual(Enumerable.Range(1, 2))
                .WriteLine("new[] { 1, 2 }.SequenceEqual(Enumerable.Range(1,2))");

            // Empty
            // Returns empty sequence of specified type
            Enumerable.Empty<int>()
                .WriteLine("Enumerable.Empty<int>()");

            // Repeat
            // Returns sequence of n identical values
            Enumerable.Repeat(1, 3)
                .WriteLine("Enumerable.Repeat(1,3)");

            // Repeat
            // Returns sequence of consecutive integers
            Enumerable.Range(1, 3)
                .WriteLine("Enumerable.Range(1, 3)");

            // First()
            //	Returns the first element of the sequence
            //	Throws an exception if the sequence is empty
            new[] { 1, 2, 3 }.First().WriteLine("new[] {1,2,3}.First()");

            // First(Func<int,bool>) 
            //	Returns the first element matching the given predicate
            //	Throws an exception if no element is found
            new[] { 1, 2, 3 }.First(x => x % 2 == 0).WriteLine("new[] {1,2,3}.First(x=>x%2==0)");

            // FirstOrDefault()
            //	Returns the first element of the sequence or
            //	default(element) if sequence is empty
            new int[0].FirstOrDefault().WriteLine("new int[0].FirstOrDefault()");

            // FirstOrDefault()
            //	Returns the first element of the sequence matching the 
            //	given predicate or default(TElement) if none match
            new[] { 1, 2, 3 }.FirstOrDefault(x => x > 3).WriteLine("new[] {1,2,3}.FirstOrDefault(x=>x>3)");

            // Last()
            //	Returns the last element of the sequence
            //	Throws an exception if the sequence is empty
            new[] { 1, 2, 3 }.Last().WriteLine("new[] {1,2,3}.Last()");

            // Last(Func<int,bool>) 
            //	Returns the last element matching the given predicate
            //	Throws an exception if no element is found
            new[] { 1, 2, 3, 4, 5 }.Last(x => x % 2 == 0).WriteLine("new[] {1,2,3,4,5 }.Last(x => x % 2 == 0)");

            // LastOrDefault()
            //	Returns the last element of the sequence or
            //	default(element) if the sequence is empty
            new int[0].LastOrDefault().WriteLine("new int[0].LastOrDefault()");

            // LastOrDefault()
            //	Returns the last element of the sequence matching the 
            //	given predicate or default(TElement) if none match
            new[] { 1, 2, 3 }.LastOrDefault(x => x > 3).WriteLine("new[] {1,2,3}.LastOrDefault(x=>x>3)");

            // Single()
            //	Returns the only element of a single element sequence
            //	Throws an exception if the sequence is empty or more 
            //  than one elemtn
            new[] { 2 }.Single().WriteLine("new[] {2.Single()");

            // Single()
            //	Returns the only element of a a sequence matching the
            // 	predicate
            //	Throws an exception no elements match the predicate or
            //	if more than one element matches the predicate
            new[] { 2 }.Single(x => x % 2 == 0).WriteLine("new[] { 2 }.Single(x=>x%2==0)");

            // SingleOrDefault()
            //	Returns the only element of a sequence if the
            //	sequence contains one element. If the collection is
            //	empty returns default(TElement). 
            //	Throws exception if the colletin has more than one
            //	elment
            new int[0].SingleOrDefault().WriteLine("new int[0].SingleOrDefault()");

            // SingleOrDefault()
            //	Returns the sinlge element of a sequence matching the
            //	predicate. If no elements match the predicate
            //	empty returns default(TElement). 
            //	Throws exception if more than one element mat
            new[] { 2 }.SingleOrDefault(x => x % 2 == 0).WriteLine("new[] { 2 }.SingleOrDefault(x=>x%2==0)");

            // ElementAt()
            //	Returns the element at given index
            //	Throws an exception out of bounds
            new[] { 1, 2, 3 }.ElementAt(1).WriteLine("new[] { 1, 2, 3 }.ElementAt(1)");

            // ElementAtOrDefault()
            //	Returns the element at given index
            //	returns default(TElement) if out of bounds
            new[] { 1, 2, 3 }.ElementAtOrDefault(5).WriteLine("new[] { 1, 2, 3 }.ElementAt(1)");

            // Concat()
            //	Returns concatenation of two sequences
            new[] { 1, 2, 3 }.Concat(new[] { 3, 4, 5 })
                .WriteLine("new[] { 1, 2, 3 }.Concat(new[] { 3, 4, 5 })");

            // Union()
            //	Returns union of two sequences (no dups)
            new[] { 1, 2, 3 }.Union(new[] { 3, 4, 5 })
                .WriteLine("new[] { 1, 2, 3 }.Union(new[] { 3, 4, 5 })");

            // Intersect()
            //	Returns intersect of two sequences (no dups)
            new[] { 1, 2, 3 }.Intersect(new[] { 3, 4, 5 })
                .WriteLine("new[] { 1, 2, 3 }.Intersect(new[] { 3, 4, 5 })");

            // Intersect()
            //	Returns elements in first sequence not in second
            new[] { 1, 2, 3 }.Except(new[] { 3, 4, 5 })
                .WriteLine("new[] { 1, 2, 3 }.Except(new[] { 3, 4, 5 })");

            // OfType()
            //	Returns elements in sequence conforming to type. 
            //	non conformant objects excluded
            new object[] { 1, "Two", 3, "Four" }.OfType<string>()
                .WriteLine(@"new object[] {1,""Two"",3,""Four""}.OfType<string>()");

            // ToArray()
            //	Returns array whose type matches sequence
            int[] arraOfInt = Enumerable.Range(1, 3).ToArray();

            // ToList()
            //	Returns list whose type matches sequence
            List<int> listOfInt = Enumerable.Range(1, 3).ToList();

            // ToDictionary()
            //	Returns dictionary (no duplicate elements)
            Enumerable.Range(1, 4).ToDictionary(x => x, y => (char)((int)'a' + y))
                .WriteLine("Enumerable.Range(1,4).ToDictionary(x=>x,y=> ((char)((int)'a')+y))");

            // ToLookup()
            //	Returns lookup which maps key to list of values with that key
            ILookup<int, int> lookup = Enumerable.Range(1, 4).ToLookup(x => x % 2);

            // Select(Func<TSource,TResult> project)
            //	Returns sequence of projected elements
            Enumerable.Range(1, 4).Select(y => (char)((int)'a' + y))
                .WriteLine("Enumerable.Range(1,4).Select(y=> (char)((int)'a'+y))");

            // Select(Func<TSource,int,TResult> project)
            //	Returns sequence of projected elements. 
            //		The project function is passed both the source 
            //		element and its index in the sequence
            Enumerable.Range(1, 4).Select((x, y) => y)
                .WriteLine("Enumerable.Range(1, 4).Select((x,y) => y)");

            // SelectMany()
            //	Returns flatened sequence of sequences
            new[] { "one", "two" }.SelectMany(x => x)
                .WriteLine(@"new[] {""one"",""two""}.SelectMany(x => x )");

            // Zip()
            //	Enumerates two sequence and applies a function to the elements
            //	at the same position in each sequence
            new[] { 1, 2 }.Zip(new[] { 'a', 'b' }, (x, y) => (x, y))
                .WriteLine("new[] { 1, 2 }.Zip(new[] { 'a', 'b' }, (x, y) => (x,y))");


            // OrderBy()
            //	Order in ascending order
            new[] { "Four", "Two", "One", "Three" }.OrderBy(x => x.Length)
                .WriteLine(@"new[] {""Four"",""Two"", ""One"",""Three""}.OrderBy(x => x.Length)");

            // ThenBy()
            //	Refine an already sorted set of elements. Only orders those with same value
            //	in previous ordering
            new[] { "Four", "Two", "One", "Three" }.OrderBy(x => x.Length).ThenBy(x => x)
                .WriteLine(@"new[] {""Four"",""Two"", ""One"",""Three""}.OrderBy(x => x.Length).ThenBy(x => x)");

            // OrderByDescending()
            //	Order in descending order
            new[] { "Four", "Two", "One", "Three" }.OrderByDescending(x => x.Length)
                .WriteLine(@"new[] {""Four"",""Two"", ""One"",""Three""}.OrderByDescending(x => x.Length)");

            // ThenByDescending()
            //	Refine an already sorted set of elements. Only orders those with same value
            //	in previous ordering
            new[] { "Four", "Two", "One", "Three" }.OrderByDescending(x => x.Length).ThenByDescending(x => x)
                .WriteLine(@"new[] {""Four"",""Two"", ""One"",""Three""}.OrderByDescending(x => x.Length).ThenByDescending(x => x)");

            // Join()
            //	Join two sequences and flatten
            var seq1 = new[] { (1, "one"), (2, "two"), };
            var seq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
            seq1.Join(seq2, outer => outer.Item1, inner => inner.Item1, (outer, inner) => (outer.Item2, inner.Item2))
                .WriteLine(@"seq1.Join(seq2,outer=>outer.Item1,inner=>inner.Item1,(outer,inner)=>(outer.Item2,inner.Item2))");

            // GroupJoin()
            //	Join two sequences and dont flatter
            seq1.GroupJoin(seq2, outer => outer.Item1, inner => inner.Item1, (outer, inner) => (outer.Item2, inner))
                .WriteLine(@"seq1.GroupJoin(seq2, outer => outer.Item1, inner => inner.Item1, (outer, inner) => (outer.Item2, inner))");

            // Aggregate
            //	 Reduce a sequence to a scalar value
            new[] { 1, 2, 3 }.Aggregate(0, (a, e) => a + e * e)
                .WriteLine("new[] { 1, 2, 3 }.Aggregate(0,(a,e) => a + e*e)");

            // Sum 
            new[] { 1, 2, 3 }.Sum(e => e * e)
                .WriteLine("new[] { 1, 2, 3 }.Sum(e=>e*e)"); 
        }
    }

    public static class Output
    {
        public static void WriteLine<TElement>(this IEnumerable<TElement> source, string statement)
        {
            Console.WriteLine(statement + " = " +
                              source.Aggregate(
                                  ("{", Index: 0),
                                  (a, e) => a.Index == 0 ? ($"{a.Item1 + e.ToString()}", ++a.Index) : ($"{a.Item1},{e.ToString()}", ++a.Index),
                                  a => $"{a.Item1}}}\n"));
        }

        public static void WriteLine<TElement>(this TElement source, string statement)
        {
            Console.WriteLine(statement + " = " + $"{source}\n");
        }
    }
}