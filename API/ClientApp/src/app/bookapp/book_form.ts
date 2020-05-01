export class BookForm {
    constructor(
        public BookId?: number,
        public BookName?: string,
        public BookFileAddress?: string,
        public AvtorsName?: string[],
        public YearOfPublishing?: string,
        public PublisherName?: string,
        public Rating?: number) { }
}