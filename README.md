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


## 3. Symbol Table
This covers the concept of creation and organization Symbol Table.

### Sample Input
```int a;
int b = 2;
float c = 5.667;
float d;```

![Screenshot of Symbol Table Code](https://github.com/khateeb321/Compiler-Construction/blob/master/images/st.PNG)
