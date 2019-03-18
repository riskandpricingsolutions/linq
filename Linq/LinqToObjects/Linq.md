# Linq
## Basic
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
}```

