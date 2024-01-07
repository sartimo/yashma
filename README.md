# yashma

Reversed yashma ransomware source code

## about

yashma is the latest prevalent variant of the ransomware-family chaos. for reference I am pointing to reports of Cyfirma and Blackberry Threat Research.
- cyfirma report: https://www.cyfirma.com/outofband/yashma-ransomware-report/
- blackberry report: https://blogs.blackberry.com/en/2022/05/yashma-ransomware-tracing-the-chaos-family-tree

## intention

I have reversed the original dotnet/csharp source code of the latest chaos v5/yashma ransomware. The malware sample I used was one that I got from a honeypot. I then fed the .exe file into Dotnet Reflector 11. I have then exported the decompiled source code. From there on, there were only small compiler errors to fix. The source code that I have provided here on github is intended to be used for research labs and educational institutions. I am not the original developer of yashma/chaos v5. I have reverse-engineered its source aswell for educational purposes only, for use within a final dissertation. The builder has been modified to warn users to its risks and to inform about potential causes and therefore about the legal responsibility before executing the builder. 

Therefore I justify myself as legally unliable for any potential causes of this source code. For any further inquiries you can notify me via email: **Timo Sarkar <sartimo10@gmail.com>**  
