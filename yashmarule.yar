import pe
import cuckoo

rule YashmaString 
{
  strings:
    $ChaosBuilder = "Chaos Ransomware" wide ascii
    $RyukString  = "Ryuk Ransomware" wide ascii

  condition:
    $ChaosBuilder or $RyukString
    filesize < 600KB
}
