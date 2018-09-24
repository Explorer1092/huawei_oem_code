data = '''9A 33 44 E3 50 96 CF 31 95 49 E4 A3 A1 13 46 63 A7 7D 0B 89 EA 05 92 56 A1 C8 30 38 C1 EF 99 B6 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 41 39 CB 0E D2 8F 6F 87 78 A8 1A 0C CA DA AB 22 5B 6E 0B A2 73 49 48 04 FF 3A BC 4D AD 90 1D C9 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00'''
import hashlib
def main():
    global data
    data = data.replace(' ','')
    part1 = data[0:64]
    part2 = data[64*2:64*3]
    oem_code = '98925750'
    print part1,part2,oem_code
    print hashlib.sha256(oem_code).hexdigest()
    print hashlib.sha256(hashlib.sha256(oem_code).digest()+part2.decode('hex')).hexdigest()
    pass
if __name__ == '__main__':
    main()
