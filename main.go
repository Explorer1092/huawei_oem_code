package main

import (
	"bytes"
	"crypto/sha256"
	"encoding/hex"
	"fmt"
	"log"
	"strconv"
	"strings"
)

func calc(message_2 []byte,message_1 []byte) bool {
	h := sha256.New()
	h.Write(message_2)
	if bytes.Equal(message_1,h.Sum(nil)) {
		return true
	}else{
		return false
	}
}
func main() {

	data := "9B 33 44 E3 50 96 CF 31 95 49 E4 A3 A1 13 46 63 A7 7D 0B 89 EA 05 92 56 A1 C8 30 38 C1 EF 99 B6 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 41 39 CB 0E D2 8F 6F 87 78 A8 1A 0C CA DA AB 22 5B 6E 0B A2 73 49 48 04 FF 3A BC 4D AD 90 1D C9 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"
	// oem_code := 98925750
	data = strings.Replace(data," ","",-1)
	message_1,err := hex.DecodeString(data[0:64])
	if err != nil {
		log.Fatal(err)
	}
	message_2,err := hex.DecodeString(data[64*2:64*3])
	if err != nil {
		log.Fatal(err)
	}

	for i:=99999999; i >0 ; i--  { // 98925750
		fmt.Println(i)
		h := sha256.New()
		h.Write([]byte(strconv.Itoa(i)))
		s := [][]byte{h.Sum(nil), message_2}
		ds := bytes.Join(s, []byte(""))

		if calc(ds,message_1) {
			fmt.Printf("%d",i)
			break
		}
	}

}

