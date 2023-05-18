#include <iostream>
#include "test.h"
#include "Python.h"

using namespace std;
static char szModule[] = { "test001" };


//�򵥵���
void Simple()
{
	cout << "��ӡsys�����б�\n";
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


//�������"Hello World"����  
void HelloWorld()
{
	cout << "\n��ӡhello World��\n";

	PyObject * pModule = NULL;//��������  
	PyObject * pFunc = NULL;//��������  
	pModule = PyImport_ImportModule(szModule);//������Ҫ���õ�Python�ļ���  
	pFunc = PyObject_GetAttrString(pModule, "HelloWorld"); //������Ҫ���õĺ�����  
	PyEval_CallObject(pFunc, NULL); //���ú���,NULL��ʾ����Ϊ��  
}


//����Add����,������int�Ͳ���  
void Add()
{
	cout << "\n����Add����,������int�Ͳ���:\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python�ļ���  
	pFunc = PyObject_GetAttrString(pModule, "add");//Add:Python�ļ��еĺ�����    //��������  
	PyObject *pArgs = PyTuple_New(2); //�������õĲ������ݾ�����Ԫ�����ʽ�����,2��ʾ��������  
	PyTuple_SetItem(pArgs, 0, Py_BuildValue("i", 5));//0---���i��ʾ����int�ͱ���  
	PyTuple_SetItem(pArgs, 1, Py_BuildValue("i", 7));//1---���//����ֵ  
	PyObject *pReturn = NULL;
	pReturn = PyEval_CallObject(pFunc, pArgs);//���ú���  
											  //������ֵת��Ϊint����  
	int result;
	PyArg_Parse(pReturn, "i", &result);//i��ʾת����int�ͱ���  
	cout << "5+7 = " << result << endl;
}

//�������ݵ�����Ϊ�ֵ�  
void TestTransferDict()
{
	cout << "\n�������ݵ�����Ϊ�ֵ䣺\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python�ļ���  
	pFunc = PyObject_GetAttrString(pModule, "TestDict"); //Add:Python�ļ��еĺ�����  
														 //��������:  
	PyObject *pArgs = PyTuple_New(1);
	PyObject *pDict = PyDict_New(); //�����ֵ����ͱ���  
	PyDict_SetItemString(pDict, "Name", Py_BuildValue("s", "WangYao")); //���ֵ����ͱ������������  
	PyDict_SetItemString(pDict, "Age", Py_BuildValue("i", 25)); //���ֵ����ͱ������������  
	PyTuple_SetItem(pArgs, 0, pDict);//0---��Ž��ֵ����ͱ�����ӵ�����Ԫ����  
									 //����ֵ  
	PyObject *pReturn = NULL;
	pReturn = PyEval_CallObject(pFunc, pArgs);//���ú���  
											  //������ֵ:  
	int size = PyDict_Size(pReturn);
	cout << "�����ֵ�Ĵ�СΪ: " << size << endl;
	PyObject *pNewAge = PyDict_GetItemString(pReturn, "Age");
	int newAge;
	PyArg_Parse(pNewAge, "i", &newAge);

	cout << "True Age: " << newAge << endl;
}

//������  
void TestClass()
{
	cout << "\n�����ࣺ\n";

	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule(szModule);//Test001:Python�ļ���  
	pFunc = PyObject_GetAttrString(pModule, "TestDict"); //Add:Python�ļ��еĺ�����  
														 //��ȡPerson��  
	PyObject *pClassPerson = PyObject_GetAttrString(pModule, "Person");
	//����Person���ʵ��  
	PyObject *pInstancePerson = PyInstance_New(pClassPerson, NULL, NULL);
	//���÷���  
	PyObject_CallMethod(pInstancePerson, "greet", "s", "Hello Kitty"); //s��ʾ���ݵ����ַ���,ֵΪ"Hello Kitty"  
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