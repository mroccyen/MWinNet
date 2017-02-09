# MWinNet

## 框架介绍
[MWinNet](https://github.com/MrocCyen/MWinNet)是基于.Net winform平台的插件式开发框架，可以根据配置文件自定义界面，通过实现框架的命令接口实现相应的功能，达到功能与界面的完全分离，添加新功能只需要将配置文件和对应的dll放入相应的文件夹内，完全插件化。

目前框架的编写已经完成了主菜单和浮动窗体，接下来还有工具栏、状态栏和右键菜单。希望大家可以多多提提意见，共同进步，同时如果你觉得这个项目还行，欢迎[fork&star](https://github.com/MrocCyen/MWinNet)。

## 框架结构
### 核心结构
#### MWinNet.Core
整个框架的核心，主要包括插件的初始化，插件树的构造，命令接口定义和通用工具类的定义。Plugin和PluginTree是插件系统的核心，每个配置文件项都对应一个插件，比如：

```
 <MenuItem path="/MWinNet/Menu/File/Create"
        id="Create"
        caption="Create"
        image="Resource\MainFrame\Test.png"
        index="0"
        assemblyName="MWinNet.MainFrame.dll"
        className="MWinNet.MainFrame.CreateCommand">
</MenuItem>
```

系统初始化的时候会读取配置文件，然后根据不同的标签构造相应的Plugin对象，然后构造插件树。

除此之外，Core中还有文件操作，字符串操作等公用的工具类。

#### MWinNet.Frame
包括界面类型的定义和框架界面的构造。界面类型包括Menu、WrokBench、DockBar、StatusBar和ContextMenu等。界面构造根据PluginTree中的Plugin构造出对应的界面对象，然后加进主界面中。

IViewContent接口是给DockWindow中添加控件的接口，每个实现了IViewContent接口的类都有与之对应的DockWindow，控件的初始化就可以放在实现了IViewContent接口的类中。

#### MWinNet.Dock
类库基于WeifenLuo.WinFormsUI.Docking修改而来。

## 框架指南
### 配置文件

### Command

### IViewContent