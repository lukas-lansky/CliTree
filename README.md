# CliTree


[![NuGet version (Newtonsoft.Json)](https://img.shields.io/nuget/v/Lansky.CliTree.svg?style=flat-square)](https://www.nuget.org/packages/Lansky.CliTree/)
![Current build status](https://ci.appveyor.com/api/projects/status/g3ws9bs994su4cai?svg=true)

A .NET library for tree pretty-printing. Very, very simple project of almost [LeftPad](https://www.theregister.co.uk/2016/03/23/npm_left_pad_chaos/)-proportions, enables you to let code like this:

```
CliTree.Print(
    new AdHocTree("root",
        new AdHocTree("child 1",
            new AdHocTree("grandchild 1",
                new AdHocTree("grandgrandchild 1"),
                new AdHocTree("grandgrandchild 2")),
            new AdHocTree("grandchild 2")),
        new AdHocTree("child 2")));
```

output this to your console:

```
root
├─ child 1
│ ├─ grandchild 1
│ │ ├─ grandgrandchild 1
│ │ └─ grandgrandchild 2
│ └─ grandchild 2
└─ child 2
```
