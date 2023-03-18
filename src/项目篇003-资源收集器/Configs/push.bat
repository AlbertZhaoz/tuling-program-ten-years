::接受参数
@echo off
echo %1 %2 %3
::复制markdown%1到指定文件夹%2
copy /Y %1 %2
::进入到跟目录%3
cd %3
git add .
git commit -m "update readme"
git push
exit
