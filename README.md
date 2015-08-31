# Compiler-Construction
This repo will be hosting some concepts of compiler construction using C#.

## 1. Parser
This covers the concept of parser. The code with the correct syntax will be parsed, otherwise not.

### Sample Inputs (This will be parsed)
```int a = 5;```
```int a;```
### Sample Error Input (This will not parse)
```inx a = 5;```

## 2. Semantic Analyzer
This covers the concept of Semantic Analyzer. The code with the correct Semantic will be parsed, otherwise not.

### Sample Inputs (This will be parsed)
```int a = 5;```

```float b = 6.7;```
### Sample Error Input (This will not parse)
```int a = 5.6;```

