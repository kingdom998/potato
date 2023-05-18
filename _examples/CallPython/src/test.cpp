#include <iostream>
#include "test.h"
#include "Python.h"

using namespace std;
static char szModule[] = { "test001" };


//简单调用
void Simple()
{
	cout << "打印sys变量列表：\n";
	try
	{
		PyRun_SimpleString("import sys");
		PyRun_SimpleString("sys.path.append( './' )");
		PyRun_SimpleString("print sys.path");
	}
	catch (...)
	{
		printf("Error to import!");
	}
}


//调用输出"Hello World"函数  
void HelloWorld()
{
	cout << "\n打印hello World：\n";

	PyObject * pModule = NULL;//声明变量  
	PyObject * pFunc = NULL;//声明变量  
	pModule = PyImport_ImportModule(szModule);//这里是要调用的Python文件名  
	pFunc = PyObject_GetAttrString(pModule, "HelloWorld"); //这里是要调用的函数名  
	PyEval_CallObject(pFunc, NULL); //调用函数,NULL表示参数为空  
}


//调用Add函数,传两个int型参数  
void Add()
{
	cout << "\n调用Add函数,传两个int型参数:\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python文件名  
	pFunc = PyObject_GetAttrString(pModule, "add");//Add:Python文件中的函数名    //创建参数  
	PyObject *pArgs = PyTuple_New(2); //函数调用的参数传递均是以元组的形式打包的,2表示参数个数  
	PyTuple_SetItem(pArgs, 0, Py_BuildValue("i", 5));//0---序号i表示创建int型变量  
	PyTuple_SetItem(pArgs, 1, Py_BuildValue("i", 7));//1---序号//返回值  
	PyObject *pReturn = NULL;
	pReturn = PyEval_CallObject(pFunc, pArgs);//调用函数  
											  //将返回值转换为int类型  
	int result;
	PyArg_Parse(pReturn, "i", &result);//i表示转换成int型变量  
	cout << "5+7 = " << result << endl;
}

//参数传递的类型为字典  
void TestTransferDict()
{
	cout << "\n参数传递的类型为字典：\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python文件名  
	pFunc = PyObject_GetAttrString(pModule, "TestDict"); //Add:Python文件中的函数名  
														 //创建参数:  
	PyObject *pArgs = PyTuple_New(1);
	PyObject *pDict = PyDict_New(); //创建字典类型变量  
	PyDict_SetItemString(pDict, "Name", Py_BuildValue("s", "WangYao")); //往字典类型变量中填充数据  
	PyDict_SetItemString(pDict, "Age", Py_BuildValue("i", 25)); //往字典类型变量中填充数据  
	PyTuple_SetItem(pArgs, 0, pDict);//0---序号将字典类型变量添加到参数元组中  
									 //返回值  
	PyObject *pReturn = NULL;
	pReturn = PyEval_CallObject(pFunc, pArgs);//调用函数  
											  //处理返回值:  
	int size = PyDict_Size(pReturn);
	cout << "返回字典的大小为: " << size << endl;
	PyObject *pNewAge = PyDict_GetItemString(pReturn, "Age");
	int newAge;
	PyArg_Parse(pNewAge, "i", &newAge);

	cout << "True Age: " << newAge << endl;
}

//测试类  
void TestClass()
{
	cout << "\n测试类：\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python文件名  
	pFunc = PyObject_GetAttrString(pModule, "TestDict"); //Add:Python文件中的函数名  
														 //获取Person类  
	PyObject *pClassPerson = PyObject_GetAttrString(pModule, "Person");
	//创建Person类的实例  
	PyObject *pInstancePerson = PyInstance_New(pClassPerson, NULL, NULL);
	//调用方法  
	PyObject_CallMethod(pInstancePerson, "greet", "s", "Hello Kitty"); //s表示传递的是字符串,值为"Hello Kitty"  
}


bool init()
{
	Py_Initialize();
	if (!Py_IsInitialized())
		return false;

	return true;

}


void uninit()
{
	Py_Finalize();
}

void callFun()
{
	Simple();
	HelloWorld();
	Add();
	TestTransferDict();
	TestClass();


}