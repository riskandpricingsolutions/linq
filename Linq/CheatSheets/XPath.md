# XPath CheatSheet
This document demonstrates various forms of XPath query on the following document

```xml
<Portfolio>
  <!-- Some Options -->
  <Option K="100" Exp="2019-01-01" />
  <Strategy>
    <Option K="110" Exp="2019-01-01" />
    <Option K="100" Exp="2020-01-01" />
  </Strategy>
  <Strategy>
    <Option K="210" Exp="2019-01-01" />
    <Option K="200" Exp="2020-01-01" />
  </Strategy>
</Portfolio>
```
### XDocument.XPathSelect("Portfolio")
Select the first child of the document of name Portfolio

##### C#
```csharp
XElement rootEl = ((IEnumerable) 
  doc
    .XPathEvaluate("Portfolio"))
    .Cast<XElement>()
    .First();
```
##### Result
```
<Portfolio>
  <!-- Some Options -->
  <Option K="100" Exp="2019-01-01" />
  <Strategy>
    <Option K="110" Exp="2019-01-01" />
    <Option K="100" Exp="2020-01-01" />
  </Strategy>
  <Strategy>
    <Option K="210" Exp="2019-01-01" />
    <Option K="200" Exp="2020-01-01" />
  </Strategy>
</Portfolio>
```
### XDocument.XPathSelect("/Portfolio")
Select the first child of the document of name Portfolio
using an absolute path. In this case the result is the
same as the previous expression as both are acting on
the root document

##### C#
```csharp
XElement rootEl2 = ((IEnumerable)
   doc
    .XPathEvaluate("/Portfolio"))
    .Cast<XElement>()
    .First();
```
##### Result
```
<Portfolio>
  <!-- Some Options -->
  <Option K="100" Exp="2019-01-01" />
  <Strategy>
    <Option K="110" Exp="2019-01-01" />
    <Option K="100" Exp="2020-01-01" />
  </Strategy>
  <Strategy>
    <Option K="210" Exp="2019-01-01" />
    <Option K="200" Exp="2020-01-01" />
  </Strategy>
</Portfolio>
```
### XElement.XPathSelect("/Portfolio")
Using a non root node, selects the root element
by using an absolute path from the root

##### C#
```csharp
XElement nonRootEl = doc.Element("Portfolio").Element("Option");
   XElement rootEl3 = 
    ((IEnumerable)nonRootEl
      .XPathEvaluate("/Portfolio"))
      .Cast<XElement>()
      .First();
```
##### Result
```
<Portfolio>
  <!-- Some Options -->
  <Option K="100" Exp="2019-01-01" />
  <Strategy>
    <Option K="110" Exp="2019-01-01" />
    <Option K="100" Exp="2020-01-01" />
  </Strategy>
  <Strategy>
    <Option K="210" Exp="2019-01-01" />
    <Option K="200" Exp="2020-01-01" />
  </Strategy>
</Portfolio>
```
### XDocument.XPathSelect("Portfolio/Strategy")
Select all Strategy children from the root document
using a relative path

##### C#
```csharp
IEnumerable<XElement> optEls = ((IEnumerable)
  doc
    .XPathEvaluate("Portfolio/Strategy"))
    Cast<XElement>()
    .ToList();
```
##### Result
```
<Strategy>
  <Option K="110" Exp="2019-01-01" />
  <Option K="100" Exp="2020-01-01" />
</Strategy>

<Strategy>
  <Option K="210" Exp="2019-01-01" />
  <Option K="200" Exp="2020-01-01" />
</Strategy>
```

### XDocument.XPathSelect("Portfolio/Strategy")
Select all Strategy children from the root document
using a relative path

##### C#
```csharp
IEnumerable<XElement> optEls = ((IEnumerable)
  doc
    .XPathEvaluate("Portfolio/Strategy"))
    Cast<XElement>()
    .ToList();
```
##### Result
```
<Strategy>
  <Option K="110" Exp="2019-01-01" />
  <Option K="100" Exp="2020-01-01" />
</Strategy>

<Strategy>
  <Option K="210" Exp="2019-01-01" />
  <Option K="200" Exp="2020-01-01" />
</Strategy>
```

### XDocument.XPathSelect("//Option")
Select all Option nodes irrespective of location
in the tree

##### C#
```csharp
IEnumerable<XElement> allOptEls = ((IEnumerable)
  doc
    .XPathEvaluate("//Option"))
    .Cast<XElement>()
    .ToList();
```
##### Result
```xml
<Option K="100" Exp="2019-01-01" />
<Option K="110" Exp="2019-01-01" />
<Option K="100" Exp="2020-01-01" />
<Option K="210" Exp="2019-01-01" />
<Option K="200" Exp="2020-01-01" />
```