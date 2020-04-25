﻿export class BookForm {
    constructor(
        public BookId?: number,
        public BookName?: string,
        public BookFileAddress?: string,
        public AvtorsName?: string[],
        public YearOfPublishing?: string,
        public PublishingHouseName?: string,
        public Rating?: number) { }
}