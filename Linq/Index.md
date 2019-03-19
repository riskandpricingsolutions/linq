# Linq
## Prerequisites
Before we can understand LINQ queries we need to introduce some prerequisites.
* Enumerators
* Enumerables
* Foreach statements
* Iterators

#### Enumerators
An enumerator is a read-only forward cursor over a collection of elements. We define enumerators by implementing the *IEnumerator<T>* interface.

```csharp
public class SimpleEnumerator : IEnumerator<int>
{	
	public int Current => i;

	object IEnumerator.Current => i;

	public void Dispose() {}

	public bool MoveNext() => i++ < 4;

	public void Reset() =>  i = -1;
	
	private int i = -1;
}
```

We can use an our enumerator as follows

```csharp
var e = new SimpleEnumerator();

while (e.MoveNext())
	WriteLine(e.Current);
```
#### Enumerables
Enumerables implement the interface *IEnumerable<T>* and produce enumerators

```csharp
public class SimpleEnumerable : IEnumerable<int>
{
	public IEnumerator<int> GetEnumerator()
	{
		return new SimpleEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
```
Enumerables are consumed by foreach statements.
var e = new SimpleEnumerable();

```csharp
foreach (var element in e)
	WriteLine(e);
```
#### Foreach Statements
Foreach statements consume enumerables. If the compiler sees a foreach statement like this

```csharp
var sequence = new List<int>( new [] {1,2,3});
	
foreach (var element in sequence)
{
	WriteLine(element);
}
```
It generates something along the lines of this
```csharp
using (IEnumerator<int> en = sequence.GetEnumerator())
{
    while (en.MoveNext())
		WriteLine(en.Current);
}
```
#### Iterators
Iterators provide an elegant means of creating enumerators and enumerables.  The following code uses iterators to produce an enumerable whose enuerators walk over the first n items in the fibonacci sequence from 0 to n-1

```csharp
IEnumerator<int> GetFibonacci(int numEntries)
{
	for (int i = 0, current = 0, next = 1, nextnext = 1;
		i < numEntries; i++)
	{
		yield return current;

		nextnext = current + next;
		current = next;
		next = nextnext;
	}
}
```
## The Basics
LINQ enables one to write type-safe queries on enumerable collections. The basic concepts are 
* Sequence		Any collection that implements IEnumerable<T>
* Element		A single constituent of the collection
* Query operator	A method that transforms one sequence into another
* Query 		A combination of query operators that performs a transform
The following piece of code shows all four together

```csharp
// 1. A sequence is any collection implementing IEnumerable<T>
IEnumerable<int> sequence = new int[] {0,1,2,3,4};
	
// 2. An element is a single constituent of the sequence
foreach (var element in sequence)
	WriteLine(element);
	
// 4. Queries combine query operators
IEnumerable<int> output = sequence
	.Where(s => s%2 ==0)
	.Select(s => s*s);
…

// 3. Query operators transform sequences
public static class QueryOperators
{
	public static IEnumerable<T> Where<T>(this IEnumerable<T> input,
 Func<T,bool> predicate)
	{
		foreach (var element in input)
			if ( predicate(element))
				yield return element;
	}
	
public static IEnumerable<TOut> Select<TOut,TIn>(this IEnumerable<TIn> input, Func<TIn,TOut> trans)
	{
		foreach (var element in input)
			yield return trans(element);
	}
}
```
Query operators are implemented as extension methods that take an enumerable argument representing an input sequence and a delegate that applies some transformation to create an output sequence. As such query operators are easily composed into queries. Most query operators are not executed when they are constructed. Instead they are executed when they are enumerated. Delayed or lazy execution provides the following benefits.
 
 * Decouples construction from execution
 * Allows one to construct a query in multiple steps
 * One can re-evaluate a query by enumerating it again



> **EXCEPTIONS TO LAZY EXECUTION**
> The following operators are exceptions which cause immediate execution
> Single element or scalar values such as *First,Count*, ToArray, ToList, ToDictionary, ToLookup*
 
